import { useHistory } from "react-router-dom"
import React from "react";

const GoBack = () =>
{
    const history = useHistory();
    return (<button onClick={history.goBack}>Voltar</button>)
}

export default GoBack;