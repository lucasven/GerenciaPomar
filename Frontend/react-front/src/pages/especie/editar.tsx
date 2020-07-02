import React, { useState, useEffect, ChangeEvent, FormEvent }  from 'react';
import { useHistory } from 'react-router-dom';
import api from '../../services/api';
import GoBack from '../../components/goBackComponent';
const EditarEspecies = ({location}:any) => {
    
    const history = useHistory();

    const [ descricao, setDescricao ] = useState<string>();
    
    useEffect(() => {
        setDescricao(location.state.especie.descricao);
    }, []);

    function changeDescricao(event: ChangeEvent<HTMLInputElement>){
        setDescricao(event.target.value);
    }

    async function handleSubmit(event: FormEvent){
        event.preventDefault();

        const codigo = location.state.especie.codigo;
        
        const data = {
            codigo,
            descricao,
        };

        await api.post("Especie", data);
        
        history.push('/especies');
    }
    
    return (
        <div>
            <GoBack />
            <form onSubmit={handleSubmit}>
                <input type="text" value={descricao} onChange={changeDescricao} />
                <button type="submit">Salvar</button>
            </form>
        </div>
    )
}

export default EditarEspecies;