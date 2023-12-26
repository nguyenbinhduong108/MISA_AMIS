<template>
    <div class="menu">
        <div class="nav">
            <router-link :to="item.to" class="nav-item" v-for="(item, index) in icons" :key="index">
                <div class="nav-icon" :style="{ 'background-position': item.position }"></div>
                <div class="nav-text">{{ item.title }}</div>
            </router-link>
        </div>
    </div>
</template>

<script>
export default {
    name: "TheMenu",
    data() {
        return {
            icons: [
                { to: '/customerList', position: ' -33px -1587px', title: `${this.$_MISAResource.menu.overView}` },
                { to: '/money', position: ' -78px -1588px', title: `${this.$_MISAResource.menu.money}` },
                { to: '/report', position: ' -552px -1593px ', title: `${this.$_MISAResource.menu.report}` },
                { to: '/', position: ' -165px -1589px', title: `${this.$_MISAResource.menu.purchase}` },
                { to: '/', position: ' -206px -1588px', title: `${this.$_MISAResource.menu.sell}` },
                { to: '/', position: ' -254px -1589px', title: `${this.$_MISAResource.menu.manageInvoices}` },
                { to: '/', position: ' -294px -1589px', title: `${this.$_MISAResource.menu.storehouse}` },
                { to: '/', position: ' -339px -1590px', title: `${this.$_MISAResource.menu.tools}` },
                { to: '/', position: ' -382px -1589px', title: `${this.$_MISAResource.menu.fixedAssets}` },
                { to: '/', position: ' -427px -1591px', title: `${this.$_MISAResource.menu.tax}` },
                { to: '/', position: ' -470px -1590px', title: `${this.$_MISAResource.menu.price}` },
                { to: '/', position: ' -514px -1590px', title: `${this.$_MISAResource.menu.synthetic}` },
                { to: '/', position: ' -427px -1664px', title: `${this.$_MISAResource.menu.budget}` },
                { to: '/', position: ' -121px -1590px', title: `${this.$_MISAResource.menu.deposits}` },
                { to: '/', position: ' -251px -1667px', title: `${this.$_MISAResource.menu.financialAnalysis}` },
            ],
        }
    }
}
</script>

<style scoped>

.router-link-active{
    background-color: #8098c7;
}
.menu {
    width: 200px;
    background-color: #041434;
    overflow-y: scroll;
}

.menu::-webkit-scrollbar{
    width: 0;
}

.nav {
    padding: 20px 12px;
}

.nav-item {
    color: #fff;
    padding: 0 12px;
    column-gap: 12px;
    height: 44px;
    display: flex;
    align-items: center;
    cursor: pointer;
    text-decoration: none;
}

.nav-item+.nav-item {
    margin-top: 4px;
}

.nav-item:hover {
    background-color: #A7C4FF;
}

.nav-item:active {
    background-color: #8ea9df;
}

.nav-item:focus {
    background-color: #8ea9df;
}


.nav-icon {
    width: 24px;
    height: 24px;
    background-image: url(../../assets/img/Sprites.64af8f61.svg);
    background-repeat: no-repeat;
}

/* @import url(../../css/icon.css); */
</style>