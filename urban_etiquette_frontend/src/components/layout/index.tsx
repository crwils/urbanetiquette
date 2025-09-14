import Navbar from "./Navbar";

const PageLayout = ({ 
    children,
}: {
    children: React.ReactNode,
}) => {
    return (
        <div className="min-h-full flex flex-col">
            <Navbar />
            <div className="grow">
                {children}
            </div>
        </div>
    );
};

export default PageLayout;
