import React from 'react';
import {

    Routes,
    Route
  } from "react-router-dom";
  import {materialsRoutes} from '../../AppRoutes.js';
  import ShowMaterials from './ShowMaterials.jsx';
  import AddItemCategory from './ItemCategory/AddItemCategory.jsx'
const MaterialGate =()=>(
    
        <div>
            <Routes>
                <Route path="/" element={<ShowMaterials />} />
                <Route path={materialsRoutes.addItemCategory} element={<AddItemCategory />} />
    
            </Routes>   
        </div>     
        );
    


export default MaterialGate;