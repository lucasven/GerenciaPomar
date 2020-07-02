import React, { useState, FormEvent, ChangeEvent, useEffect } from "react";
import { useHistory } from "react-router-dom";
import api from "../../services/api";
import GoBack from "../../components/goBackComponent";
import { DatePicker, MuiPickersUtilsProvider } from '@material-ui/pickers';
import DateFnsUtils from '@date-io/date-fns';

interface especie{
    codigo: string,
    descricao: string
}

const EditarArvore = ({location}:any) => {

    const history = useHistory();

    const [ selectedEspecie, setSelectedEspecie ] = useState<string>();

    const [ especies, setEspecies ] = useState<especie[]>([]);

    const [ dataPlantio, setDataPlantio ] = useState<Date|null>();

    const [descricao, setDescricao] = useState<string>();

    useEffect(() => {
        api.get("Especie?pagina=1&total=10").then(response =>{
                setEspecies(response.data);
            })
    }, []);

    useEffect(() => {
        setDescricao(location.state.arvore.descricao);
        setDataPlantio(location.state.arvore.dataPlantio);
        setSelectedEspecie(location.state.arvore.codigoEspecie);
    }, []);

    async function handleSubmit(event: FormEvent){
        event.preventDefault();
        const codigo = location.state.arvore.codigo;
        const codigoEspecie = selectedEspecie;
        const  data = {
            codigo,
            descricao,
            dataPlantio,
            codigoEspecie
        }
        await api.post("Arvore", data);
        
        history.push('/arvores');
    }

    function handleChangePlantio(date: Date|null){
        setDataPlantio(date);
    }

    function handleSelectEspecie(event: ChangeEvent<HTMLSelectElement>){
        setSelectedEspecie(event.target.value);
    }

    function handleDescricaoChange(event: ChangeEvent<HTMLInputElement>){
        setDescricao(event.target.value);
    }

    return (
        <div>
            <GoBack />
            <form onSubmit={handleSubmit}>
                <div className="field">
                    <label >Descrição: </label>
                    <input type="text" value={descricao} onChange={handleDescricaoChange} />
                </div>
                <div className="field">
                    <label >Data do Plantio: </label>
                    <MuiPickersUtilsProvider utils={DateFnsUtils}>
                        <DatePicker value={dataPlantio} onChange={handleChangePlantio} />
                    </MuiPickersUtilsProvider>
                </div>
                <div className="field">
                    <label>Especie: </label>
                    <select value={selectedEspecie} onChange={handleSelectEspecie}>
                        <option value="0">Selecione a especie</option>
                        {especies.map(especie => (
                            <option value={especie.codigo}>{especie.descricao}</option>
                        ))}
                    </select>
                </div>
                <button type="submit">Salvar</button>
            </form>
        </div>
    )

    
}

 export default EditarArvore;
// import React, { useState, useEffect, ChangeEvent, FormEvent }  from 'react';
// import { useHistory } from 'react-router-dom';
// import api from '../../services/api';
// import GoBack from '../../components/goBackComponent';
// const EditarArvore = ({location}:any) => {
    
//     const history = useHistory();

//     const [ descricao, setDescricao ] = useState<string>();
    
//     useEffect(() => {
//         setDescricao(location.state.arvore.descricao);
//     }, []);

//     function changeDescricao(event: ChangeEvent<HTMLInputElement>){
//         setDescricao(event.target.value);
//     }

//     async function handleSubmit(event: FormEvent){
//         event.preventDefault();

//         const codigo = location.state.arvore.codigo;
        
//         const data = {
//             codigo,
//             descricao,
//         };

//         await api.post("Especie", data);
        
//         history.push('/especies');
//     }
    
//     return (
//         <div>
//             <GoBack />
//             <form onSubmit={handleSubmit}>
//                 <input type="text" value={descricao} onChange={changeDescricao} />
//                 <button type="submit">Salvar</button>
//             </form>
//         </div>
//     )
// }

// export default EditarArvore;