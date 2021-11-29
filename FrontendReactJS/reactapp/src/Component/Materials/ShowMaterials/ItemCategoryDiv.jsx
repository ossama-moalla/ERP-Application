const ItemCategoryDiv=(props)=>{
    return(
        <div className="hover" style={{float:"left" }} >
            <div className="div-inlineblock">      
                <img alt="" src={process.env.PUBLIC_URL + '/category.png'}
                style={{width:50,height:50,verticalAlign:"sub",cursor:"pointer"}}
                onClick={()=>props.onClick(props.category.ID)} /> 
            </div>
            <div className="div-inlineblock">
                <button className="btn-text" onClick={()=>props.onClick(props.category.ID)}>{props.category.name} </button><br/>
                <button className="btn-text" ><i  className=" bi-info-lg"style={{color:"green"}} ></i></button>
                <button className="btn-text"><i  className=" bi-pencil" style={{color:"blue"}}></i></button>
                <button className="btn-text" onClick={()=>props.onDelete(props.category.ID)}><i className="bi bi-x-lg" style={{color:"red"}}></i></button>
            </div> 
            
        </div>

    );
}
export default ItemCategoryDiv;