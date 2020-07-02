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

const NovaArvore = () => {

    useEffect(() => {
        api.get("Especie?pagina=1&total=10").then(response =>{
                setEspecies(response.data);
            })
    }, []);

    const history = useHistory();

    const [ selectedEspecie, setSelectedEspecie ] = useState<string>();

    const [ especies, setEspecies ] = useState<especie[]>([]);

    const [ dataPlantio, setDataPlantio ] = useState<Date|null>();

    function handleChangePlantio(date: Date|null){
        setDataPlantio(date);
    }

    const [descricao, setDescricao] = useState<string>();

    async function handleSubmit(event: FormEvent){
        event.preventDefault();
        const codigoEspecie = selectedEspecie;
        const  data = {
            descricao,
            dataPlantio,
            codigoEspecie
        }
        await api.post("Arvore", data);
        
        history.push('/arvores');
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
                    <label htmlFor="descricao">Descrição: </label>
                    <input 
                    type="text" 
                    onChange={handleDescricaoChange} 
                    name="descricao"
                    id="descricao"/>
                </div>
                <div className="field">
                    <label htmlFor="descricao">Data do Plantio: </label>
                    <MuiPickersUtilsProvider utils={DateFnsUtils}>
                        <DatePicker value={dataPlantio} onChange={handleChangePlantio} />
                    </MuiPickersUtilsProvider>
                </div>
                <div className="field">
                    <label htmlFor="uf">Especie</label>
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

export default NovaArvore;