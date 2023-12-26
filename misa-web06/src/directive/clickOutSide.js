const clickOutSide = {
    beforeMount: (el,binding)=>{ 
        el.clickOutSideEvent = event =>{
            if(!(el == event.target || el.contains(event.target))){
                binding.value();
            }
        }
        document.addEventListener('click',el.clickOutSideEvent,true);
    },
    unmounted: el =>{
        document.removeEventListener('click',el.clickOutSideEvent,true);
    }
}
export default clickOutSide;