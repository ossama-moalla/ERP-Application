const ExtractErrorMessage=(err)=>{
    try{
        return err.response.data.message
    }catch{
        return 'Unknown Error'
    }
}
const toggleDivByCheckbox=(e,divId)=>{
    var s=document.getElementById(divId);
    if(e.target.checked) s.style.display="block";
    else s.style.display="none"
}
export {ExtractErrorMessage,toggleDivByCheckbox}