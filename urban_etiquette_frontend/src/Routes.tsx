import { Route, Routes } from "react-router-dom";
import Homepage from "./pages/Homepage";
import { useAppPaths } from "./utils/appPaths";
import ExplorePage from "./pages/Explore";

const AppRoutes: React.FC = () => {
    
const appPaths = useAppPaths();

    return (
        <Routes>
            <Route index path={appPaths.home} element={<Homepage />} />
            <Route path={appPaths.explore} element={<ExplorePage />} />
            {/* <Route path={appPaths.fourOFour} element={<FourOFour />} /> */}
        </Routes>
    );
};

export default AppRoutes;
