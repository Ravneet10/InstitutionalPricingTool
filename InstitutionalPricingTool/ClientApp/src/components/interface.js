export function getProposals() {
    return fetch('https://localhost:44342/InstitutionalPricing/getproposals')
  .then(response =>{
    return response.json();});
    
  }

  export function getFacilities(proposalId) {
    console.log("test",proposalId)
    return fetch('https://localhost:44342/InstitutionalPricing/getFacilities?proposalId='+ proposalId)
  .then(response =>{
    return response.json();});
    
  }