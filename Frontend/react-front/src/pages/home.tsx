import React from 'react';
// import { FiLogIn } from 'react-icons/fi';
import { Link } from 'react-router-dom';
 
const Home = () => {
    return (
        <div id="page-home">
            <div className="content">
                <header>
                    
                </header>

                <main>
                    <h1>Gerenciamento de pomar</h1>

                    <Link to="/especies">
                        <strong>Especies</strong>
                    </Link>
                    <br/>
                    <Link to="/arvores">
                        <strong>Árvores</strong>
                    </Link>
                    <br/>
                    <Link to="/grupoarvores">
                        <strong>Grupo de Árvores</strong>
                    </Link>
                    <br/>
                    <Link to="/colheita">
                        <strong>Colheita</strong>
                    </Link>
                </main>
            </div>
        </div>
    )
}

export default Home;