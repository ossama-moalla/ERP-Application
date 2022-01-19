import ItemInfo from './ItemInfo.jsx';
import ItemUpdate from './ItemUpdate.jsx';
const ItemDiv=(props)=>{
    return(
        <div className="hover" style={{float:"left" }} >
            <div className="div-inlineblock">      
                <img alt="" src={process.env.PUBLIC_URL + '/product.png'}
                style={{width:50,height:50,verticalAlign:"sub",cursor:"pointer"}}
                /*onClick={()=>props.openCategory(props.category.id)}*/ /> 
            </div>
            <div className="div-inlineblock">
                <button className="btn-text" style={{width:"100%",textAlign:"left"}}
                 /*onClick={()=>props.openCategory(props.category.id)}*/>
                    <span style={{color:"blue",marginRight:10,fontWeight:"bold"}}>{props.item.name}</span>
                    <span style={{color:"brown",fontWeight:"bold"}}>{props.item.company}</span> 
                </button><br/>
                <button className="btn-text" >
                    <i  className=" bi-info-lg"style={{color:"green"}}
                     onClick={()=>
                     props.showPopUpComponent(
                     <ItemInfo 
                     closePopUpComponent={props.closePopUpComponent}
                      item={props.item}/>,'Item Info')} ></i>
                </button>
                <button className="btn-text" 
                    onClick={()=>
                        props.showPopUpComponent(
                        <ItemUpdate
                        closePopUpComponent={props.closePopUpComponent}
                        openCategory={props.openCategory}
                        item={props.item}/>,'Update Item:'+props.item.name)}>
                    <i  className=" bi-pencil" style={{color:"blue"}}></i>
                </button>
                <button className="btn-text" onClick={()=>props.onDelete(props.item.id,props.item.name)}>
                    <i className="bi bi-x-lg" style={{color:"red"}}></i>
                </button>
            </div> 
            
        </div>

    );
}
export default ItemDiv;