const ExtractErrorMessage=(err)=>{
    try{   
      if(err.response){
        if(err.response.data.message)
        return err.response.data.message
        else{
          if(err.response.statusText)
            return err.response.status+' '+ err.response.statusText
          else
          return 'Network Error(maybe server is down)'

        }
      }  
      else
        return 'Unknown Error:'+err  
    }catch{
        return 'Unknown Error'
    }
}
const getOperationName=(typeID)=>{
  switch(typeID){
    case 1:return "Bill Buy";
    case 2:return "Bill Sell";
    case 3:return "BILL MAINTENANCE";
    case 4:return "Employee PayOrder";
    case 5:return "MAINTENANCE OPR";
    case 6:return "ASSEMBLAGE";
    case 7:return "DISASSEMBLAGE";
    case 8:return "Ravage OPR";
    case 9:return "REPAIR OPR";
    default:return "unknown operation"
  }
}
const toggleDivByCheckbox=(e,divId)=>{
    var s=document.getElementById(divId);
    if(e.target.checked) s.style.display="block";
    else s.style.display="none"
}

function makeDragable(dragHandle, dragTarget) {


    let dragObj = null; 
    let xOffset = 0;
    let yOffset =0;
  
    document.querySelector(dragHandle).addEventListener("mousedown", startDrag, true);
    document.querySelector(dragHandle).addEventListener("touchstart", startDrag, true);

    function startDrag(e) {
      e.preventDefault();
      e.stopPropagation();
      dragObj = document.querySelector(dragTarget);
      if (e.type==="mousedown") {
        xOffset = e.clientX - dragObj.offsetLeft; 
        yOffset = e.clientY -  dragObj.offsetTop;
        window.addEventListener('mousemove', dragObject, true);
      } else if(e.type==="touchstart") {
        xOffset = e.targetTouches[0].clientX - dragObj.offsetLeft;
        yOffset = e.targetTouches[0].clientY - dragObj.offsetTop;
        window.addEventListener('touchmove', dragObject, true);
      }
    }
  
    function dragObject(e) {
      e.preventDefault();
      e.stopPropagation();
    
      if(dragObj === null) {
        return; 
      } else if(e.type==="mousemove") {
        dragObj.style.left = e.clientX-xOffset +"px"; 
        dragObj.style.top = e.clientY-yOffset +"px";
      } else if(e.type==="touchmove") {
        dragObj.style.left = e.targetTouches[0].clientX-xOffset +"px"; 
        dragObj.style.top = e.targetTouches[0].clientY-yOffset +"px";
      }
    }
  
    document.onmouseup = function(e) {
      if (dragObj) {
        dragObj = null;
        window.removeEventListener('mousemove', dragObject, true);
        window.removeEventListener('touchmove', dragObject, true);
      }
    }
  }
  
export {ExtractErrorMessage,getOperationName,toggleDivByCheckbox,makeDragable}