import React, {useEffect, useState } from 'react';
import api from '../../services/api';
import { Link, useHistory } from 'react-router-dom';
import GoBack from '../../components/goBackComponent';

interface Especie {
    codigo: string;
    descricao: string;
}

const ListarEspecies = () => {
    const history = useHistory();
    const [ especies, setEspecies ] = useState<Especie[]>([]);
    
    useEffect(() => {
        carregarEspecies();
    }, []);

    function carregarEspecies(){
        api.get("Especie?pagina=1&total=10").then(response =>{
            setEspecies(response.data);
        })
    }

    async function excluirEspecie(codigo:string){
        await api.delete(`Especie?codigo=${codigo}`);
        carregarEspecies();
    }

    return (
        <div id="page-lista-especie">
            <GoBack />
            <button onClick={() => {history.push('especies/novo')}}>
                Adicionar Novo
            </button>
            <ul>
            {especies &&
              especies.map((especie, index) => (
                <li
                key={index}>
                    {especie.descricao}
                    <Link to={{
                            pathname: `/especies/editar/${especie.codigo}`,
                            state: { especie }
                        }}
                    >Editar</Link>

                    <button onClick={() => {excluirEspecie(especie.codigo)}}>Excluir</button>
                </li>
              ))}
            </ul>
        </div>
    )
}

export default ListarEspecies;