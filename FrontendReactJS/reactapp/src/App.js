import logo from './logo.svg';
import './App.css';
import { createStore} from 'redux';
import {Provider } from 'react-redux';
import {Route} from 'react-router'
import MoneyAccountWindow from './Component/Accounting/MoneyAccountWindow';
import Footer from './Component/Footer'
const ApplicationReducer=(state,action)=>{

}

let store=createStore(ApplicationReducer);
const App=()=>(
  <Provider store={store}>
    <div >
    <MoneyAccountWindow/>
    <Footer/>
    </div>
  </Provider>
);

export default App;
