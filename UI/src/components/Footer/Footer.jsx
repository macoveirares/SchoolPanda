/*eslint-disable*/
import React from "react";
// reactstrap components
import { Container, Row, Nav, NavItem, NavLink } from "reactstrap";

class Footer extends React.Component {
  render() {
    return (
      <footer className="footer">
        <Container fluid>
        <Nav>
            <NavItem>
              <NavLink href="javascript:void(0)">Our Team</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="javascript:void(0)">GitHub</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="javascript:void(0)">Documentation</NavLink>
            </NavItem>
          </Nav>
          <div className="copyright">
            © {new Date().getFullYear()}
            <a
              href="javascript:void(0)"
              rel="noopener noreferrer"
              target="_blank"
            >
              Panda Team
            </a>{" "}
            for INET Course.
          </div>
        </Container>
      </footer>
    );
  }
}

export default Footer;
