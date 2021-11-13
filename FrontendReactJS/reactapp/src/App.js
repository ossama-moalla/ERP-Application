import logo from './logo.svg';
import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css';
import './CSS/color.css';
import './CSS/general.css';
import { createStore} from 'redux';
import {Provider } from 'react-redux';
import {Route} from 'react-router'
import MoneyAccountWindow from './Component/Accounting/MoneyAccountWindow';
import Footer from './Component/Footer'
import DisplayMaterials from './Component/Materials/DisplayMaterials';
const ApplicationReducer=(state,action)=>{

}

let store=createStore(ApplicationReducer);
const App=()=>(
  <Provider store={store}>

    <DisplayMaterials/>
  </Provider>
);

export default App;
