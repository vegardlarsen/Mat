# Mat

> In the picture framing industry, a *mat* (or mount in British English) is a thin, flat piece of paper-based material included within a picture frame, which serves as additional decoration and to perform several other, more practical functions, such as separating the art from the glass. — [Wikipedia][wikipedia]

*Mat* is a software suite designed to run digital picture frames.

**Note**: Mat is currently just a prototype, so don't expect everything to work just yet.

## How it works

Mat runs in two parts, a client and a server. 

The server handles finding image sources (through configuration), and controls which image is shown.

The client is basically a small HTML/Javascript page that receives instructions from the server.

## Setting up

Simply build and run Mat (using Visual Studio 2010 or above), and with the default configuration it will serve the images from your Sample pictures folder. You can easily modify the configuration to add pictures from other folders.

## Configuration

Mat is configured through `Web.config`, under `<mat>`.  It is by default set up to serve images from a local directory (the Sample pictures folder) and a single image from my Flickr account.

Mat supports multiple data sources.

### Local images

The local image data source (the `<local />` tag in the configuration) monitors a single folder on your machine, and displays all the images in that folder.

If an image is added when the server is already running, it will be picked up and displayed next.

### Static source

The static source allows you to link directly to individual images on an external server. You can add as many images as you like, but the URLs have to be encoded in the `Web.config` file, and to add more images you have to restart the server.

### Planned sources

These are ideas on sources I want to add, but haven't gotten around to:

* **Flickr** -  Connect directly to a Flickr photostream of any sort.
* **Remote** -  Allow a remote computer (running a separate program) to upload images to the server (think of it as a "remote local folder").
* **Dropbox** - Connect to a Dropbox account via their API, and get images from a Dropbox app-folder.

## Other plans

* **Security** Currently the service is completely open, meaning all images are available to anyone.
* **Configurability** Configure things like time per image, ordering, and so on.
* **Remote control** Let you skip an image, pause on an image, and so on.

[wikipedia]: http://en.wikipedia.org/wiki/Mat_(picture_framing)