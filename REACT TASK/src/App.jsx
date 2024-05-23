import React from "react";
import { Flex } from "antd";
import { Breadcrumb, Layout, Menu, theme } from "antd";
import "./App.css";
import "./Components/card"
import card from "./Components/card"
const { Header, Content, Footer } = Layout;
const items = new Array(3).fill(null).map((_, index) => ({
  key: index + 1,
  label: `naviqasiya ${index + 1}`,
}));
const App = () => {
  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();
  return (
    <Layout>
      <Header
        style={{
          display: 'flex',
          alignItems: 'center',
          justifyContent:"center",
          width:"100%",
       
        }}
        className="header-me"
      >
        <img
          src="https://os.alipayobjects.com/rmsportal/mlcYmsRilwraoAe.svg"
          alt=""
        />
        <Menu
          theme="dark"
          mode="horizontal"
          defaultSelectedKeys={["2"]}
          items={items}
          style={{
            flex: 1,
            justifyContent:"flex-end",
            // minWidth: 0,
          }}
        />
      </Header>

      <Footer
        style={{
          textAlign: "center",
        }}
      >
        Ant Design ©{new Date().getFullYear()} Created by Ant UED
      </Footer>
    </Layout>
  );
};
export default App;

