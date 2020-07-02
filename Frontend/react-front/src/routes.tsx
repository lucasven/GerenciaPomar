import React from 'react';
import { Route, BrowserRouter } from 'react-router-dom';

import Home from './pages/home'
import ListarEspecies from './pages/especie/lista';
import EditarEspecies from './pages/especie/editar';
import NovaEspecie from './pages/especie/novo';
import ListarArvores from './pages/arvore/lista';
import NovaArvore from './pages/arvore/novo';
import EditarArvore from './pages/arvore/editar';
import NovoGrupoArvore from './pages/grupoArvore/novo';
import EditarGrupoArvore from './pages/grupoArvore/editar';
import ListarGrupoArvore from './pages/grupoArvore/lista';

const Routes = () => {
    return(
        <BrowserRouter>
            <Route component={Home} path="/" exact />
            <Route path={'/especies'} component={ListarEspecies}  exact/>
            <Route path={'/especies/editar/:codigo'} component={EditarEspecies} exact/>
            <Route path={'/especies/novo'} component={NovaEspecie} exact/>
            <Route path={'/arvores'} component={ListarArvores}  exact/>
            <Route path={'/arvores/novo'} component={NovaArvore}  exact/>
            <Route path={'/arvores/editar/:codigo'} component={EditarArvore} exact/>
            <Route path={'/grupoarvores'} component={ListarGrupoArvore}  exact/>
            <Route path={'/grupoarvores/novo'} component={NovoGrupoArvore}  exact/>
            <Route path={'/grupoarvores/editar/:codigo'} component={EditarGrupoArvore} exact/>
        </BrowserRouter>
    )
}

export default Routes;