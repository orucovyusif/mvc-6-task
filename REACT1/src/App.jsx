import { useState } from "react";
import "./App.css";


function App() {
const [signIn,setSignIn]=useState(false)
  function Login(){
    setSignIn(true)
  }
  function Logout(){
    setSignIn(false)
  }
  
  return (
   <div>
    {signIn ?(
      <button>sign In</button>
<p>welcome</p>
   </div>

    )}

  );
}

export default App;
