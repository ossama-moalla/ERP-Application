const ExtractErrorMessage=(err)=>{
    try{
      if(err.response.data.message)
        return err.response.data.message
      else{
        if(err.response.statusText)
          return err.response.status+' '+ err.response.statusText
        else
          return 'Unknown Error'

      }
    }catch{
        return 'Unknown Error'
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
      if (e.type=="mousedown") {
        xOffset = e.clientX - dragObj.offsetLeft; 
        yOffset = e.clientY -  dragObj.offsetTop;
        window.addEventListener('mousemove', dragObject, true);
      } else if(e.type=="touchstart") {
        xOffset = e.targetTouches[0].clientX - dragObj.offsetLeft;
        yOffset = e.targetTouches[0].clientY - dragObj.offsetTop;
        window.addEventListener('touchmove', dragObject, true);
      }
    }
  
    function dragObject(e) {
      e.preventDefault();
      e.stopPropagation();
    
      if(dragObj == null) {
        return; 
      } else if(e.type=="mousemove") {
        dragObj.style.left = e.clientX-xOffset +"px"; 
        dragObj.style.top = e.clientY-yOffset +"px";
      } else if(e.type=="touchmove") {
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
  
export {ExtractErrorMessage,toggleDivByCheckbox,makeDragable}