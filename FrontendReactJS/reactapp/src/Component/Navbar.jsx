import React,{Component} from 'react';
//import { useHistory } from 'react-router-dom';


export default class Navbar extends Component{
    render(){
      console.log('nav render')
        return(
            <nav className="navbar navbar-expand-lg navbar-light " >
  <div className="container-fluid">
    <a className="navbar-brand" href="/">Materials</a>
    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span className="navbar-toggler-icon"></span>
    </button>
    <div className="collapse navbar-collapse" id="navbarNav">
    <ul style={{color:"white"}} className="navbar-nav me-auto mb-2 mb-lg-0" >
        <li className="nav-item">
          <a className="nav-link active" aria-current="page" href="/">any thing</a>
        </li>
        <li className="nav-item">
          <a className="nav-link" href="/">Features</a>
        </li>
      </ul>
      <span className="navbar-brand mb-0 h1" style={{color:"green"}}>Welcome:{localStorage.getItem("email")}</span>

      <ul className="navbar-nav ms-auto mb-2 mb-lg-0">
                 
                <li className="nav-item">
                     <a className="nav-link" href="/-" >-</a>
                 </li>
                 <li className="nav-item">
                     <a className="nav-link" href="/resetpassword">Reset Password</a>
                 </li>
                 <li className="nav-item">
                     <a className="nav-link" href="/" onClick={()=>{
                        const toLogout=window.confirm("Are you sure to logout ?");
                        /* eslint-enable */
                        if (toLogout) {
                          localStorage.clear();
                         }
                     }}>  Logout</a>
                 </li>
                 </ul>
    </div>
  </div>
</nav>
        );

    }
}
