export function getProposals() {
    return fetch('https://localhost:44342/api/institutionalpricingtool/getproposals')
  .then(response =>{
    console.log("response",response)
    response.json()})
  .then(data => console.log(data));
    
  }