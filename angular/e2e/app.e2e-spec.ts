import { TusharBhagatTemplatePage } from './app.po';

describe('TusharBhagat App', function() {
  let page: TusharBhagatTemplatePage;

  beforeEach(() => {
    page = new TusharBhagatTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
