import React, { Fragment } from 'react';
import {
    Routes,
    Route
  } from "react-router-dom";
  import ShowMaterials from './ShowMaterials/ShowMaterials.jsx';



const MaterialGate =()=>(
    
        <Fragment>
            <Routes>
                <Route path="/" exact element={<ShowMaterials />} />

            </Routes>   
        </Fragment>     
        );
    


export default MaterialGate;