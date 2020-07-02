import React, { useState, useEffect } from "react";
import GoBack from "../../components/goBackComponent";
import { Link, useHistory } from "react-router-dom";
import api from "../../services/api";

interface Arvore {
    codigo: string;
    descricao: string;
    idade: number;
    codigoEspecie: string;
    especie:{
        descricao: string;
    }
}

const ListarArvores = () => {

    const [ arvores, setArvores ] = useState<Arvore[]>([]);

    const history = useHistory();

    useEffect(() => {
        carregarArvores();
    }, []);

    function carregarArvores(){
        api.get("Arvore?pagina=1&total=10").then(response =>{
            setArvores(response.data);
        })
    }
    

    async function excluirArvore(codigo:string){
        await api.delete(`Arvore?codigo=${codigo}`);
        carregarArvores();
    }

    return (
        <div id="page-lista-arvores">
            <GoBack />
            <button onClick={() => {history.push('arvores/novo')}}>
                Adicionar Novo
            </button>
            <ul>
            {arvores &&
              arvores.map((arvore, index) => (
                <li
                key={index}>
                    <span>Descrição: </span> {arvore.descricao}
                    <br/>
                    <span>Idade: </span> {arvore.idade}
                    <br/>
                    <span>Especie: </span> {arvore.especie.descricao}
                    <br/>
                    <Link to={{
                            pathname: `/arvores/editar/${arvore.codigo}`,
                            state: { arvore }
                        }}
                    >Editar</Link>
                    <br/>
                    <button onClick={() => {excluirArvore(arvore.codigo)}}>Excluir</button>
                </li>
              ))}
            </ul>
        </div>
    )
}

export default ListarArvores;