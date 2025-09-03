import * as React from "react";

const MainPage : React.FC = () => {
    return (
        <div>
            <img
                src="https://xl-static.rozetka.com.ua/assets/img/main/rozetka.png"
                alt="Logo"
                style={{ display: 'block', margin: '0 auto', transform: 'scale(0.5)', maxWidth: '100%', height: 'auto' }}
            />
            <p style={{textAlign:'center'}}>TEAM-PROJECT</p>
        </div>
    )
}

export default MainPage;