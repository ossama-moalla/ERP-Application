import 'bootstrap/dist/css/bootstrap.min.css';
import "bootstrap/js/src/collapse.js";

import './App.css';
import './CSS/color.css';
import './CSS/general.css';
import './CSS/tab_page.css';

import React from 'react'
import {
  BrowserRouter,
  Routes,
  Route
} from "react-router-dom";
//import Footer from './Component/Footer'
import Navbar from './Component/Navbar.jsx';
import ShowMaterials from './Component/Materials/ShowMaterials/ShowMaterials.jsx';
import MoneyAccountWindow from './Component/Accounting/ShowAccountInfo/MoneyAccountWindow.jsx'
import Configuration from './Component/Configuration/Configuration';
import Dealers from './Component/Trade/Dealer/Dealers.jsx';
const App=()=>(
  <React.Fragment>
    {<Navbar/>}
    <BrowserRouter>
        <Routes>
        <Route path="/"  element={<Dealers/>}/>
        <Route path="/Trade/dealers"  element={<Dealers/>}/>
        <Route path="/configuration"  element={<Configuration/>}/>
        <Route path="accounting/*"  element={<MoneyAccountWindow/>}/>
        <Route  path={'materials/*'}  element={<ShowMaterials/>} />
        </Routes>
        </BrowserRouter>
  </React.Fragment>
);

export default App;
