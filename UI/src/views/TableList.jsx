import React from "react";

// reactstrap components
import {
  Card,
  CardHeader,
  CardBody,
  CardTitle,
  Table,
  Row,
  Col
} from "reactstrap";

class Tables extends React.Component {
  render() {
    return (
      <>
        <div className="content">
          <Row>
            <Col md="12">
              <Card>
                <CardHeader>
                  <CardTitle tag="h4">Simple Table</CardTitle>
                </CardHeader>
                <CardBody>
                  <Table className="tablesorter" responsive>
                    <thead className="text-primary">
                      <tr>
                        <th>Name</th>
                        <th>Country</th>
                        <th>City</th>
                        <th className="text-center">Credits</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <td>Calin Zapan</td>
                        <td>Romania</td>
                        <td>Iasi</td>
                        <td className="text-center">222</td>
                      </tr>
                      <tr>
                        <td>Macovei Rares</td>
                        <td>Romania</td>
                        <td>Iasi</td>
                        <td className="text-center">240</td>
                      </tr>
                      <tr>
                        <td>Ciornei Octav</td>
                        <td>Romania</td>
                        <td>Iasi</td>
                        <td className="text-center">230</td>
                      </tr>
                      <tr>
                        <td>Esanu Andra</td>
                        <td>Romania</td>
                        <td>Iasi</td>
                        <td className="text-center">150</td>
                      </tr>
                      <tr>
                        <td>Ripan Vladimir</td>
                        <td>Romania</td>
                        <td>Iasi</td>
                        <td className="text-center">300</td>
                      </tr>
                      <tr>
                        <td>Maftei Robert</td>
                        <td>Romania</td>
                        <td>Iasi</td>
                        <td className="text-center">190</td>
                      </tr>
                      <tr>
                        <td>Tanasuca Manuel</td>
                        <td>Romania</td>
                        <td>Iasi</td>
                        <td className="text-center">140</td>
                      </tr>
                    </tbody>
                  </Table>
                </CardBody>
              </Card>
            </Col>
          </Row>
        </div>
      </>
    );
  }
}

export default Tables;
