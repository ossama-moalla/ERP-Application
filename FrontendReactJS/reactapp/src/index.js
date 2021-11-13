import reactDom from 'react-dom';
import { Provider } from 'react-redux';
import { createStore } from 'redux';
import App from './App';


reactDom.render(<App/>,document.getElementById('root'))