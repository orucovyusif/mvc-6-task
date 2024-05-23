import {Route,Routes}from "react-router-dom"
import Home from "./Pages/Home"
import About from "./Pages/About"
import Product from "./Pages/Product"
import Productdetails from "./Pages/Productdetail"
import Contact from "./Pages/Contact"
import Navbar from "./Components/Navbar"
import './App.css'

function App() {
  return (
    <>
  <Navbar/>
  <Routes>
    <Route path="/home" element={<Home/>}></Route>
    <Route path="/about" element={<About/>}></Route>
    <Route path="/product" element={<Product/>}></Route>
    <Route path="/productdetails" element={<Productdetails/>}></Route>
    <Route path="/contact" element={<Contact/>}></Route>
    </Routes>
    </>
  )
}

export default App
