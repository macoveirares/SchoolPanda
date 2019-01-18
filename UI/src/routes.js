import Dashboard from "views/Dashboard.jsx";
import TableList from "views/TableList.jsx";
import UserProfile from "views/UserProfile.jsx";

var routes = [
  {
    path: "/dashboard",
    name: "Dashboard",
    icon: "tim-icons icon-chart-pie-36",
    component: Dashboard,
    layout: "/admin"
  },
  {
    path: "/user-profile",
    name: "User Profile",
    icon: "tim-icons icon-single-02",
    component: UserProfile,
    layout: "/admin"
  },
  {
    path: "/group",
    name: "Your Group",
    icon: "tim-icons icon-puzzle-10",
    component: TableList,
    layout: "/admin"
  },
];
export default routes;
