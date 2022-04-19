import React from "react";
import { Button } from "reactstrap";
import ProposalsPage from "./ProposalsPage";

class InstitutionPricingPage extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      showProposals: false,
    };
  }
  onButtonClick = () => {
    this.setState({ showProposals: true });
  };
  render() {
    return (
      <>
        <Button
          style={{ backgroundColor: "#24a0ed" }}
          onClick={this.onButtonClick}
        >
          Get Data
        </Button>
        {this.state.showProposals && (<ProposalsPage />)}
      </>
    );
  }
}
export default InstitutionPricingPage;
