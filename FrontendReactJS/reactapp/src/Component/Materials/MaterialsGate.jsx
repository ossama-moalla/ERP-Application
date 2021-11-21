import React, { Fragment } from 'react';
import {

    Routes,
    Route
  } from "react-router-dom";
  import {materialsRoutes} from '../../AppRoutes.js';
  import ShowMaterials from './ShowMaterials.jsx';
  import AddItemCategoryFormik from './ItemCategory/AddItemCategoryFormik.jsx'
const MaterialGate =()=>(
    
        <Fragment>
            <Routes>
                <Route path="/" element={<ShowMaterials />} />
                <Route path={materialsRoutes.addItemCategory} element={<AddItemCategoryFormik />} />
    
            </Routes>   
        </Fragment>     
        );
    


export default MaterialGate;