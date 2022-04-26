export function getProposals() {
    return fetch('https://institutionpricing.azurewebsites.net/InstitutionalPricing/getproposals')
  .then(response =>{
    return response.json();});
    
  }

  export function getFacilities(proposalId) {
    return fetch('https://institutionpricing.azurewebsites.net/InstitutionalPricing/getFacilities?proposalId='+ proposalId)
  .then(response =>{
    return response.json();});
    
  }