import ItemCategoryInfo from '../ItemCategory/ItemCategoryInfo.jsx';
import ItemCategoryUpdate from '../ItemCategory/ItemCategoryUpdate.jsx';
const ItemCategoryDiv=(props)=>{
    return(
        <div className="hover" style={{float:"left" }} >
            <div className="div-inlineblock">      
                <img alt="" src={process.env.PUBLIC_URL + '/category.png'}
                style={{width:50,height:50,verticalAlign:"sub",cursor:"pointer"}}
                onClick={()=>props.openCategory(props.category.id)} /> 
            </div>
            <div className="div-inlineblock">
                <button className="btn-text"  onClick={()=>props.openCategory(props.category.id)}>
                    {props.category.name} 
                </button><br/>
                <button className="btn-text" >
                    <i  className=" bi-info-lg"style={{color:"green"}}
                     onClick={()=>
                     props.showPopUpComponent(
                     <ItemCategoryInfo 
                     closePopUpComponent={props.closePopUpComponent}
                      Category={props.category}/>,'Category Info')} ></i>
                </button>
                <button className="btn-text" 
                    onClick={()=>
                        props.showPopUpComponent(
                        <ItemCategoryUpdate
                        closePopUpComponent={props.closePopUpComponent}
                        refreshCategoryList={props.refreshCategoryList}
                        Category={props.category}/>,'Update Category:'+props.category.name)}>
                    <i  className=" bi-pencil" style={{color:"blue"}}></i>
                </button>
                <button className="btn-text" onClick={()=>props.onDelete(props.category.id,props.category.name)}>
                    <i className="bi bi-x-lg" style={{color:"red"}}></i>
                </button>
            </div> 
            
        </div>

    );
}
export default ItemCategoryDiv;