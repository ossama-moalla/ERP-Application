import React, { Fragment } from 'react';
import {
    Routes,
    Route
  } from "react-router-dom";
  import ShowMaterials from './ShowMaterials/ShowMaterials.jsx';
  import AddItemCategory from './ItemCategory/AddItemCategory.jsx';
  import ItemCategorySpecs from './ItemCategory/ItemCategorySpecs.jsx';


const MaterialGate =()=>(
    
        <Fragment>
            <Routes>
                <Route path="/" exact element={<ShowMaterials />} />
                <Route path={'itemcategory/add'} element={<AddItemCategory/>} />
                <Route path={'itemcategory/specs'} element={<ItemCategorySpecs/>} />
            </Routes>   
        </Fragment>     
        );
    


export default MaterialGate;