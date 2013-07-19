(function ($) {
    var KEYS = {
        LEFT: 37,
        UP: 38,
        RIGHT: 39,
        DOWN: 40
    };
    $(function () {
        var container = $('.container'),
            hub = $.connection.mediaHub;
        hub.newImage = function (image, backwards, displayTime) {
            $('.status').text('Loading image...');
            container.find('.previous,.next').remove();
            var newImage = $('<img />').attr('src', image.url),
                newSlideClass = !!backwards ? "previous" : "next",
                oldSlideClass = !!backwards ? "next" : "previous",
                newSlide = $('<div />').addClass('slide').addClass(newSlideClass).append(newImage);
            container.append(newSlide);
            // wait until image loads
            newImage.on('load', function () {
                container.find('.active').toggleClass('active').toggleClass(oldSlideClass);
                var windowHeight = $(window).height();
                var imageHeight = newImage.height();
                newImage.animate({ marginTop: (windowHeight - imageHeight) / 2 }, displayTime, 'linear');

                newSlide.toggleClass('active').toggleClass(newSlideClass);

                if ($('.logoLoader').size() > 0) {
                    // wait until animation has run before removing
                    setTimeout(function () {
                        $('.logoLoader').remove();
                    }, 5000);
                }
            });
        };
        $.connection.hub.start(function () {
            $('.status').text('Awaiting instructions...');
            console.log(hub.displayTime);

            $(document).on('keydown', function (e) {
                switch (e.which) {
                    case KEYS.LEFT:
                        hub.previousImage();
                        return false;
                    case KEYS.RIGHT:
                        hub.nextImage();
                        return false;
                }
            });
        });
    });
} (jQuery));