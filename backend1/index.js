const express = require("express");
const port = 8080;
const app = express();
app.use(express.json())
let users = [
  {
    id: 1,
    userName: "Leyla",
    userEmail: "tu7h94majcode.edu.az",
    age: 19,
  },
  {
    id: 2,
    userName: "salam",
    userEmail: "tu7h94majcode.edu.az",
    age: 20,
  },
  {
    id: 3,
    userName: "necesen",
    userEmail: "tu7h94majcode.edu.az",
    age: 21,
  },
  {
    id: 4,
    userName: "salammmmmm",
    userEmail: "tu7h94majcode.edu.az",
    age: 22,
  },
];
let counter=1000;
app.get("/users", (req, res) => {
  res.send(users);
});
app.get("/users/:id", (req, res) => {
  const { id } = req.params;
  const result = users.find((item) => item.id == id);
  res.send(result);
});

app.listen(port,()=>{
    console.log(`jddkefj${port}`);
})

app.post("/users",(req,res)=>{
    const{userName,userEmail,age}=req.body;
    users.push({id:counter,userName,userEmail,age})
    counter++;
    res.send("data ugurla yaradildi...");
})