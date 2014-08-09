UTAU Bulk Envelope Editor
======================

Plugin for [UTAU](http://en.wikipedia.org/wiki/Utau), for bulk-editing long note envelopes in UST files.

![Screenshot](https://github.com/riipah/utauBulkEnvelopeEditor/blob/master/media/screenshot.png)

## How to use ##

1. Select one or more notes in UTAU.
2. Start the plugin (from Tools -> Plug-ins -> BulkEnvelopeEdit)
3. Enter p and v values for the envelope ending points ("3" and "4"; if available "5" as well) that you wish to be changed. The values will only be applied if the note is followed by a rest. Values not entered in the editor are not touched, but if the note is missing points that were specified in the editor, those points will be created. You may also enter a minimum length for the notes where the editor will apply.
4. Press the button which applies the changes and closes the plugin.

## Installation ##

1. Make sure [.NET framework 4.5.1](http://www.microsoft.com/fi-fi/download/details.aspx?id=40773) (or newer) is installed.
2. Build (requires Visual Studio 2013) or [download the binary](http://vocaloid.eu/files/bulkEnvelopeEdit.zip).
3. Copy the binary AND plugin.txt to the plugin folder under UTAU's installation folder, for example C:\UTAU\plugins\bulkEnvelopeEdit

## Example ##

1. Open UST file containing notes ki, mi, no, ko, e, R, wo, where "R" is the rest.
2. Select the "e" note (you may also select all notes, as long as "e" is selected).
3. Open the plugin.
4. Enter 666 for p3.
5. Press the button.
6. Open the envelope editor for the "e" note in UTAU (by pressing ctrl+y).
7. p3 value for the envelope is set to 666.

- - -
Thanks to a friend for the idea (you know who you are :))