
// Fetch Data From CustomerOne and Save it to CustomerTwo

const Sync = async (term) => {
    console.log(term);
    let uri = 'http://localhost:3000/customer1';
  
    let uriTwo = 'http://localhost:3000/customer2';
  
    const resTwo = await fetch(uriTwo);
    const customersTwo = await resTwo.json();
    console.log(customersTwo);
  
  
    const res = await fetch(uri);
    const customers = await res.json();
    console.log(customers);
  
    let toAdd = [];
    let toUpdate = [];
   
  
     customers.forEach(e => {
  
      const currentItem = customersTwo.find(x => x.id === e.id);
      // Add 
     if (currentItem == null) {
        toAdd.push({name: e.name })
     } else {
       toUpdate.push({id: currentItem.id, name: e.name })
       // Updated 
     } 
    });
  
toAdd.forEach(obj => {
        fetch("http://localhost:3000/customer2", {
        method: "POST",
        body: JSON.stringify(obj),
        headers: { "Content-Type": "application/json" },
      });
});

// toUpdate.forEach(x => {
//     fetch("http://localhost:3000/customer2", {
//     method: "PUT",
//     body: JSON.stringify(x),
//     headers: { "Content-Type": "application/json" },
//   });
// });
};


  

