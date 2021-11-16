// javascript for index.html
const container = document.querySelector('.blogs');
const container2 = document.querySelector('.blogs2');
const searchForm = document.querySelector('.search');

const renderPosts = async (term) => {
  console.log(term);
  let uri = 'http://localhost:3000/customer1';

  let uriTwo = 'http://localhost:3000/customer2';

  const res = await fetch(uri);
  const customers = await res.json();
  console.log(customers);

  const resTwo = await fetch(uriTwo);
  const customersTwo = await resTwo.json();
  console.log(customersTwo);




  let toAdd = [];
  let toUpdate = [];
   let count = customers.length;

  
   

   customersTwo.forEach(e => {

    const currentItem = customers.find(x => x.id === e.id);
    // Add 
   if (currentItem == null) {
      count++
      toAdd.push({"id": count, "name":e.name })
   } else {
     toUpdate.push({"id": currentItem.id, "name": e.name })
     // Updated 
   } 
  });


  let template = '<h1> Customers location one </h1>';
  customers.forEach(customer => {
    template += `
      <div class="post">
        <h2>${customer.name}</h2>
        <p><small> ID number: ${customer.id}</small></p>
        <a href="/details.html?id=${customer.id}">View Customer</a>
      </div>
    `
  });
  template += '<h1> Customers location two </h1>';
  customersTwo.forEach(customer => {
    template += `
      <div class="post">
        <h2>${customer.name}</h2>
        <p><small> ID number: ${customer.id}</small></p>
        <a href="/details.html?id=${customer.id}">View Customer</a>
      </div>
    `
  });

  container.innerHTML = template;
}




window.addEventListener('DOMContentLoaded', () => renderPosts());
