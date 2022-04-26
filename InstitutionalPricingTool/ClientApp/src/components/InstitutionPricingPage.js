import React from "react";
import { Button } from "reactstrap";
import ProposalsPage from "./ProposalsPage";
import { getProposals } from "./interface";

class InstitutionPricingPage extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      showProposals: false,
      proposalList: null,
      isLoading: false,
      errorMessage: null,
    };
  }

  onButtonClick = () => {
    this.setState({ showProposals: true });
    getProposals()
      .then((result) => {
        this.setState({ isLoading: false, proposalList: result });
      })
      .catch((x) => {
        this.setState({ isLoading: false, errorMessage: x });
      });
  };
  render() {
    const { errorMessage, isLoading } = this.state;
    return (
      <>
        <Button
          style={{ backgroundColor: "#24a0ed" }}
          onClick={this.onButtonClick}
        >
          Get Data
        </Button>
        {errorMessage != null && <div>Some Error Occurred</div>}
        {isLoading && <div>Loading in progress ...</div>}
        {!isLoading && this.state.showProposals && (
          <ProposalsPage proposalsList={this.state.proposalList} />
        )}
      </>
    );
  }
}
export default InstitutionPricingPage;
