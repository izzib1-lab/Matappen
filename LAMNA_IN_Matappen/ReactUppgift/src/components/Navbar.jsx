import { Link } from "react-router-dom";
import { FaHome, FaUtensils } from "react-icons/fa";

function Navbar() {
  return (
    <nav className="navbar">
      <div className="container nav-container">
        <p className="logo">🍽️ Matappen</p>

        <ul>
          <li>
            <Link to="/home">
              <FaHome /> Hem
            </Link>
          </li>
          <li>
            <Link to="/mat">
              <FaUtensils /> Mat
            </Link>
          </li>
        </ul>
      </div>
    </nav>
  );
}

export default Navbar;