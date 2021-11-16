// javascript for create.html
const form = document.querySelector("form");

// Creats a new customer in "Customer ONE"

const createPost = async (e) => {
  e.preventDefault();

  const doc = {
    name: form.name.value,
  };

  await fetch("http://localhost:3000/customer1", {
    method: "POST",
    body: JSON.stringify(doc),
    headers: { "Content-Type": "application/json" },
  });

  window.location.replace("/");
};

form.addEventListener("submit", createPost);
