import React, { useEffect,useState } from 'react'
import { Helmet, HelmetProvider } from 'react-helmet-async';
import axios from "axios"
const Product = () => {
    const [data,setData]=useState([])
   useEffect(()=>{
axios.get("https://fakestoreapi.com/products").then(leyla=>{
    console.log(leyla.data);
    setData(leyla.data);
})
   },[]) 
  return (
    <div>
    <Helmet>
    <title>product</title>
    <link rel="canonical" href="https://www.tacobell.com/" />
  </Helmet>
 <div className="cards">
    <div className="card">
        <div className="header-card">
            <img src="https://cdn.dsmcdn.com/ty1162/product/media/images/prod/SPM/PIM/20240207/04/461eb0db-c697-3981-9703-0dc19a0e8dfe/1_org_zoom.jpg" alt="" />
        </div>
        <div className="body-card">
            <p>$69</p>
            <p>Classic Heather Gray</p>
            <p>Hoodie</p>
        </div>
    </div>
    <div className="card">
        <div className="header-card">
            <img src="https://cdn.dsmcdn.com/ty1162/product/media/images/prod/SPM/PIM/20240207/04/461eb0db-c697-3981-9703-0dc19a0e8dfe/1_org_zoom.jpg" alt="" />
        </div>
        <div className="body-card">
            <p>$69</p>
            <p>Classic Heather Gray</p>
            <p>Hoodie</p>
        </div>
    </div>
 </div>
</div>
  )}
export default Product