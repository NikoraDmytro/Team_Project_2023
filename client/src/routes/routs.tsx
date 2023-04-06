import {createBrowserRouter, Navigate} from "react-router-dom";
import {RegistrationPage} from "./RegistrationPage";
import {HomePage} from "./HomePage";
import {App} from "../App";
import { CalendarPage } from "./CalendarPage";

export const router = createBrowserRouter([
  {
    path: "/register",
    element: <RegistrationPage/>,
  },
  {
    path: "/",
    element: <App />,
    children: [
      {
				index: true,
				element: <Navigate to="/home" replace={true} />,
			},
      {
        path: "home",
        element: <HomePage/>
      },
      {
        path: "calendar",
        element: <CalendarPage/>
      }
    ]
  },
]);