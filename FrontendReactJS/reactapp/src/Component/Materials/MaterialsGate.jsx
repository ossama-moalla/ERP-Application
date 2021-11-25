import React, { Fragment } from 'react';
import {

    Routes,
    Route
  } from "react-router-dom";
  import {materialsRoutes} from '../../AppRoutes.js';
  import ShowMaterials from './ShowMaterials/ShowMaterials.jsx';
  import AddItemCategory from './ItemCategory/AddItemCategory.jsx'
const MaterialGate =()=>(
    
        <Fragment>
            <Routes>
                <Route path="/" element={<ShowMaterials />} />
                <Route path={materialsRoutes.addItemCategory+":id"} element={<AddItemCategory/>} />
    
            </Routes>   
        </Fragment>     
        );
    


export default MaterialGate;