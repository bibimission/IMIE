$(".book").mouseenter(function(){
  $(this).parent(".book-wrap").addClass("rotate");
});

$(".book").mouseleave(function(){
  $(this).parent(".book-wrap").removeClass("rotate");
});

$(".book").click(function(){
  $(this).parent(".book-wrap").addClass("flip");
  //$("#circle").hide();
});

$(".book-back").click(function(){
  $(this).parent(".book-wrap").removeClass("flip");
  //$("#circle").show();
});

/* Every time the window is scrolled ... */
$(window).scroll( function(){

	/* Check the location of each desired element */
	$('.hideme').each( function(i){
		var bottom_of_object = $(this).offset().top + $(this).outerHeight();
		var bottom_of_window = $(window).scrollTop() + $(window).height();
		
		/* If the object is completely visible in the window, fade it it */
		if( bottom_of_window > bottom_of_object ){
			$(this).animate({'opacity':'1'},700);
		}
		
	}); 

});

$('.view-pdf').on('click',function(){
        var pdf_link = $(this).attr('href');
        var iframe = '<div class="iframe-container"><iframe src="'+pdf_link+'"></iframe></div>'
        $.createModal({
        title:'My Title',
        message: iframe,
        closeButton:true,
        scrollable:false
        });
        return false;        
    });