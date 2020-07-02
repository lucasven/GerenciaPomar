import React, { useState, useEffect, ChangeEvent, FormEvent }  from 'react';
import { withRouter, useHistory } from 'react-router-dom';
import api from '../../services/api';
import GoBack from '../../components/goBackComponent';
const NovaEspecie = () => {
    
    const history = useHistory();

    const [ descricao, setDescricao ] = useState<string>();
    
    function changeDescricao(event: ChangeEvent<HTMLInputElement>){
        setDescricao(event.target.value);
    }

    async function handleSubmit(event: FormEvent){
        event.preventDefault();

        const data = {
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

export default NovaEspecie;