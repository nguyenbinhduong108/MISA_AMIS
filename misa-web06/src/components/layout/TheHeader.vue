<template>
    <div class="header">
        <div class="header-left">
            <div class="icon-container-24px" style="background-color: #ffffff00;">
                <div class="icon"></div>
            </div>
            <div class="logo"></div>
        </div>
        <div class="header-right">
            <div class="left">
                <div class="icon-container-24px">
                    <div class="icon"></div>
                </div>
                CÔNG TY TNHH SẢN XUẤT - THƯƠNG MẠI QUI PHÚC
                <div class="icon-container-24px">
                    <div class="icon"></div>
                </div>
            </div>
            <div class="right">
                <div class="icon-container-40px">
                    <div class="icon"></div>
                </div>

                <div class="icon-container-40px">
                    <div class="icon"></div>
                </div>
                Nguyễn Bình Dương
                <div class="icon-container-24px">
                    <div class="icon"></div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "TheHeader",
}
</script>

<style scoped>
.header{
    width: 100%;
    height: 56px;
    display: flex;
}

.header .header-left {
    display: flex;
    width: 200px;
    height: 56px;
    align-items: center;
    column-gap: 16px;
    padding: 0 16px;
    background-color: #041434;
}

.header .header-left .icon {
    background: url('../../assets/img/Sprites.64af8f61.svg');
    background-repeat: no-repeat;
    background-position: -428px -92px;
    width: 24px;
    height: 24px;
}

.header .header-left .logo {
    height: 36px;
    flex: 1;
    background-image: url(../../assets/img/Logo_Module_TiengViet_White.66947422.svg);
    background-size: contain;
    background-repeat: no-repeat;
    background-position: center;
}

.header .header-right {
    height: 100%;
    flex: 1;
    display: flex;
    align-items: center;
    justify-content: space-between;
    background-color: #ffffff;
}

.header .header-right .left {
    font-family: Roboto;
    font-weight: 700;
    font-size: 14px;
    display: flex;
    align-items: center;
    column-gap: 8px;
    margin-left: 8px;
}

.header .header-right .left div:nth-child(1) .icon {
    width: 16px;
    height: 14px;
    background-image: url(../../assets/img/Sprites.64af8f61.svg);
    background-position: -847px -35px;
    background-repeat: no-repeat;
}

.header-right .left div:nth-child(2) .icon {
    width: 9px;
    height: 5px;
    background-image: url(../../assets/img/Sprites.64af8f61.svg);
    background-position: -947px -366px;
    background-repeat: no-repeat;
}

.header .header-right .right {
    font-family: Roboto;
    font-weight: 700;
    font-size: 14px;
    display: flex;
    align-items: center;
    column-gap: 8px;
    margin-right: 8px;
}

.header .header-right .right div:nth-child(1) .icon {
    width: 22px;
    height: 25px;
    background-image: url(../../assets/img/Sprites.64af8f61.svg);
    background-position: -788px -30px;
}

.header .header-right .right div:nth-child(2) .icon {
    width: 32px;
    height: 32px;
    background-image: url(../../assets/img/Sprites.64af8f61.svg);
    background-position: -352px -894px;
    background-repeat: no-repeat;
    border-radius: 90px;
}

.header .header-right .right div:nth-child(3) .icon {
    width: 9px;
    height: 5px;
    background-image: url(../../assets/img/Sprites.64af8f61.svg);
    background-position: -947px -366px;
    background-repeat: no-repeat;
}



</style>