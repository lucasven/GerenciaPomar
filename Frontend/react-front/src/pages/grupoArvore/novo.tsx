import React, { useState, useEffect, ChangeEvent, FormEvent }  from 'react';
import { withRouter, useHistory } from 'react-router-dom';
import api from '../../services/api';
import GoBack from '../../components/goBackComponent';

interface Arvore{
    codigo:string;
    descricao:string;
    especie: {
        descricao:string;
    }
}

const NovoGrupoArvore = () => {
    
    const history = useHistory();

    const [arvores, setArvores] = useState<Arvore[]>([]);

    const [arvoresSelecionadas, setArvoresSelecionadas] = useState<string[]>([""]);

    const [ descricao, setDescricao ] = useState<string>();

    const [ nome, setNome ] = useState<string>();
    
    useEffect(() => {
        api.get("Arvore?pagina=1&total=10").then(response =>{
            setArvores(response.data);
        })
    }, []);

    function changeDescricao(event: ChangeEvent<HTMLInputElement>){
        setDescricao(event.target.value);
    }

    function changeNome(event: ChangeEvent<HTMLInputElement>){
        setNome(event.target.value);
    }

    function adicionarArvore(event: FormEvent){
        event.preventDefault();
        setArvoresSelecionadas([...arvoresSelecionadas, ""]);
    }

    function excluirArvore(i:number){
        let nova = [...arvoresSelecionadas];
        nova.splice(i, 1);
        setArvoresSelecionadas([...nova]);
    }

    async function handleSubmit(event: FormEvent){
        event.preventDefault();

        const arvores = arvoresSelecionadas.map((c => ({codigo: c})));

        const data = {
            nome,
            descricao,
            arvores
        };

        await api.post("GrupoArvore", data);
        
        history.push('/grupoArvores');
    }
    
    function handleSelectArvore(idx:number, event: ChangeEvent<HTMLSelectElement>){
        let arvs = [...arvoresSelecionadas];
        arvs[idx] = event.target.value;
        setArvoresSelecionadas([...arvs]);
    }

    return (
        <div>
            <GoBack />
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Nome:</label>
                    <input type="text" value={nome} onChange={changeNome} />
                </div>
                <br/>
                <div>
                    <label>Descrição:</label>
                    <input type="text" value={descricao} onChange={changeDescricao} />
                </div>
                <br/>
                <div>
                    {arvoresSelecionadas.map((arvore, idx) => (
                        <div  id={`divTotal${idx}`}>
                            <span>arvore</span>
                            <select id={`arvores${idx}`} value={arvore} onChange={(val) => handleSelectArvore(idx, val)}>
                                <option value="0">Selecione a arvore</option>
                                {arvores.map(arv => (
                                    <option value={arv.codigo}>{arv.descricao} - {arv.especie.descricao}</option>
                                ))}
                            </select>
                            <i onClick={() => excluirArvore(idx)}>Excluir</i>
                        </div>
                    ))}
                    <button type="button" onClick={adicionarArvore}>Adicionar Arvore</button>
                </div>
                <br/>
                <button type="submit">Salvar</button>
            </form>
        </div>
    )
}

export default NovoGrupoArvore;