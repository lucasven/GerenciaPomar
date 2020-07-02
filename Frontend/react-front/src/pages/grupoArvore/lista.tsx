import React, {useEffect, useState } from 'react';
import api from '../../services/api';
import { Link, useHistory } from 'react-router-dom';
import GoBack from '../../components/goBackComponent';

interface GrupoArvore {
    codigo: string;
    nome:string;
    descricao: string;
    arvores: [{
        descricao:string;
    }]
}

const ListarGrupoArvore = () => {
    const history = useHistory();
    const [ grupoArvores, setGrupoArvores ] = useState<GrupoArvore[]>([]);
    
    useEffect(() => {
        carregarGrupoArvores();
    }, []);

    function carregarGrupoArvores(){
        api.get("GrupoArvore?pagina=1&total=10").then(response =>{
            setGrupoArvores(response.data);
        })
    }

    async function excluirGrupoArvore(codigo:string){
        await api.delete(`GrupoArvore?codigo=${codigo}`);
        carregarGrupoArvores();
    }

    return (
        <div id="page-lista-especie">
            <GoBack />
            <button onClick={() => {history.push('grupoarvores/novo')}}>
                Adicionar Novo
            </button>
            <ul>
            {grupoArvores &&
              grupoArvores.map((grupoArvore, index) => (
                <li
                key={index}>
                    {grupoArvore.descricao}
                    <Link to={{
                            pathname: `/grupoarvores/editar/${grupoArvore.codigo}`,
                            state: { grupoArvore }
                        }}
                    >Editar</Link>

                    <button onClick={() => {excluirGrupoArvore(grupoArvore.codigo)}}>Excluir</button>
                </li>
              ))}
            </ul>
        </div>
    )
}

export default ListarGrupoArvore;