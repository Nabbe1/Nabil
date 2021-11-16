// javascript for details.html
const id = new URLSearchParams(window.location.search).get("id");
const container = document.querySelector(".details");
const deleteBtn = document.querySelector(".delete");
const form = document.querySelector("form");


const renderDetails = async () => {
  const res = await fetch("http://localhost:3000/customer1/" + id);

  const customer = await res.json();

  const resTwo = await fetch("http://localhost:3000/customer2/" + id);

  const customerTwo = await resTwo.json();

  let template = `
  <h1> Customers location ONE </h1>
    <h1>${customer.name}</h1>

  `;
  template += `
  <h1> Customers location TWO </h1>
  <h1>${customerTwo.name}</h1>

`;

  container.innerHTML = template;
};

// Deletes Customer

deleteBtn.addEventListener("click", async () => {
  const res = await fetch("http://localhost:3000/customer1/" + id, {
    method: "DELETE",
  });
  const resTwo = await fetch("http://localhost:3000/customer2/" + id, {
    method: "DELETE",
  });
  window.location.replace("/");
});

// Updates Customer

const updatePost = async (e) => {
  e.preventDefault();

  const doc = {
    name: form.name.value,
  };

  const res = await fetch("http://localhost:3000/customer1/" + id, {
    method: "PUT",
    body: JSON.stringify(doc),
    headers: { "Content-Type": "application/json" },
  });
  const resTwo = await fetch("http://localhost:3000/customer2/" + id, {
    method: "PUT",
    body: JSON.stringify(doc),
    headers: { "Content-Type": "application/json" },
  });
  window.location.replace("/");
};

window.addEventListener("DOMContentLoaded", renderDetails);

form.addEventListener("submit", updatePost);
