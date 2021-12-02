import 'bootstrap/dist/css/bootstrap.min.css';
import "bootstrap/js/src/collapse.js";

import './App.css';
import './CSS/color.css';
import './CSS/general.css';
import { createStore} from 'redux';
import {Provider } from 'react-redux';
import {
  BrowserRouter,
  Routes,
  Route
} from "react-router-dom";
//import Footer from './Component/Footer'
import Navbar from './Component/Navbar.jsx';
import MaterialGate from './Component/Materials/MaterialsGate';
const ApplicationReducer=(state,action)=>{
  
}

let store=createStore(ApplicationReducer);

const App=()=>(
  <Provider store={store}>
    <Navbar/>
    <BrowserRouter>

        <Routes>
        <Route path="/" element={<div>hhhh</div>} />

        <Route  path={'materials/*'}  element={<MaterialGate/>} />
        

        </Routes>
        </BrowserRouter>
  </Provider>
);

export default App;
